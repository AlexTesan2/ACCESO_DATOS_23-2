using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;

namespace Repasando.Pages.Alumnos
{
    public class EditModel : PageModel
    {
		[BindProperty]
        public Alum alumno { get; set; }
        public IAlumRepositorio alumRepositorio { get; set; }
		public IWebHostEnvironment Iwhet { get; }
		[BindProperty]
		public IFormFile Photo { get; set; }
        public EditModel(IAlumRepositorio alumRepositorio, IWebHostEnvironment iwhet)
        {
            this.alumRepositorio = alumRepositorio;
			Iwhet = iwhet;
		}
        public IActionResult OnGet(int? id)
        {
			if (id.HasValue)
			{
				alumno = alumRepositorio.GetAlum(id.Value);
			}
			else 
			{ 
				alumno=new Alum();
			}
			return Page();
        }

		public IActionResult OnPost(Alum alum)
		{
			if (ModelState.IsValid)//si he rellenado todos los campos required
			{
				if (Photo != null)
				{
					{
						if (alumno.Foto != null)
						{
							string filePath = Path.Combine(Iwhet.WebRootPath, "Imgs", alumno.Foto);
							System.IO.File.Delete(filePath);
						}
					}
					alumno.Foto = ProcessUploadedFile();
				}
				if (alum.ID != 0)
					alumRepositorio.Update(alumno);
				else
					alumRepositorio.Add(alumno);
				return RedirectToPage("Index");
			}
			else
				return Page();
		}


		private string ProcessUploadedFile()
		{
            if(Photo != null)
            {
				//necesitamos un objeto de una clase que sea capaz de manipular el proyecto por lo que la creamos en el constructor
				string uploadsFolder = Path.Combine(Iwhet.WebRootPath, "Imgs");//lo primero nos devuelve el path a wwwroot
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
