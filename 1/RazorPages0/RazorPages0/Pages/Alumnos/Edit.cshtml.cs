using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Modelos;
using RazorPages.Services;

namespace RazorPages0.Pages.Alumnos
{
    public class EditModel : PageModel
    {
		private readonly IAlumnoRepositorio AlumnoRepositorio;
		private readonly IWebHostEnvironment webHostEnvironment;
		[BindProperty]
		public Alumno alumno { get; set; }
		[BindProperty]
		public IFormFile Photo { get; set; }
		public EditModel(IAlumnoRepositorio alumnoRepositorio, IWebHostEnvironment webHostEnvironment)
		{
			this.AlumnoRepositorio = alumnoRepositorio;
			this.webHostEnvironment = webHostEnvironment;
		}
		public IActionResult OnGet(int? id)
		{
			if (id.HasValue)
			{
				alumno = AlumnoRepositorio.GetAlumno(id.Value);
			}
			else 
			{
				alumno=new Alumno();
			}
			return Page();
		}

		public IActionResult OnPost(Alumno alumno)
		{
			if (ModelState.IsValid)
			{
				if (Photo != null)
				{
					if (alumno.Foto != null)
					{
						string filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", alumno.Foto);
						System.IO.File.Delete(filePath);
					}
					alumno.Foto = ProcessUploadedFile();
				}

				if (alumno.Id > 0)
				{
					AlumnoRepositorio.Update(alumno);
				}
				else
				{
					AlumnoRepositorio.Add(alumno);
				}
				return RedirectToPage("Index");
			}
			else
			{
				return Page();
			}
		}
		private string ProcessUploadedFile()
		{
			if(Photo != null)
			{
				//necesitamos un objeto de una clase que sea capaz de manipular el proyecto por lo que la creamos en el constructor
				string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");//lo primero nos devuelve el path a wwwroot
				string filePath = Path.Combine(uploadsFolder, Photo.FileName);
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					Photo.CopyTo(fileStream);
				}
			}
			return Photo.FileName;
		}
	}
}
