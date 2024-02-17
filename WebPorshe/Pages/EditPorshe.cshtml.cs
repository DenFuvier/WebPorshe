using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPorshe.Model;
using WebPorshe.repository;

namespace WebPorshe.Pages
{
    public class EditPorsheModel : PageModel
    {
        private IPorshe _porsheRepository;

        public EditPorsheModel(IPorshe porsheRepository)
        {
            _porsheRepository = porsheRepository;
        }

        public Porshe Porshe { get; set; }

        public IActionResult OnGet(int id)
        {
            Porshe = _porsheRepository.Get(id);
            Porshe ??= new Porshe();
            return Page();
        }

        public IActionResult OnPost(Porshe porsheForm)
        {
            var updatedPorshe = _porsheRepository.Update(porsheForm);
            if (updatedPorshe == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}