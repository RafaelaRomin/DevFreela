using System.Globalization;

namespace DevFreela.Application.ViewModels
{
    public class SkillViewModel
    {
        public SkillViewModel(string description)
        {
            Description = description;
        }

        public string Description { get; set; }
    }

}