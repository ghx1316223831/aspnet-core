using System.Linq;
using System.Threading.Tasks;
using Abp.Localization;
using Microsoft.AspNetCore.Mvc;

namespace DH.Inspection.Web.Views.Shared.Components.AccountLanguages
{
    public class AccountLanguagesViewComponent : InspectionViewComponent
    {
        private readonly ILanguageManager _languageManager;

        public AccountLanguagesViewComponent(ILanguageManager languageManager)
        {
            _languageManager = languageManager;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            var model = new LanguageSelectionViewModel
            {
                CurrentLanguage = _languageManager.CurrentLanguage,
                Languages = _languageManager.GetLanguages().Where(l => !l.IsDisabled).ToList()
                .Where(l => !l.IsDisabled)
                .ToList(),
                CurrentUrl = Request.Path
            };

            return Task.FromResult(View(model) as IViewComponentResult);
        }
    }
}
