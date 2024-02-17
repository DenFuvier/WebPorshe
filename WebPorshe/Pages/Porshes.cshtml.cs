using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebPorshe.Model;
using WebPorshe.repository;
using WebPorshe.Repository;

namespace WebPorshe.Pages
{
    public class PorshesModel : PageModel
    {

        public PorshesModel(IPorshe porsheRepository)
        {
            _porsheRepository = porsheRepository;
        }
        private IPorshe _porsheRepository;
        public List<Porshe> porshes { get; set; }
        public IActionResult OnGet()
        {
            porshes = _porsheRepository.GetAll();
            return Page();
        }

    }
}
