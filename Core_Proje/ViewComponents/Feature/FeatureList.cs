using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Feature
{
    public class FeatureList:ViewComponent //Eğer bir projede View Component ile parçalama yapıyorsak, O sayfaya ait bir Component klası olmalı ve ViewComponent inherit edilmelidir!
    {

        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());
        // Backend işlemlerini gerçekleştirmek için(Listeleme) FeatureManager klasını çağırdık(Newleme) 
        public IViewComponentResult Invoke()//Invoke view componente gitmeyi sağlayan metodtur -Shared içinde Default.cshtml açılır
        {
            var values=featureManager.TGetList();
            return View(values); //(FeatureManager içindeki Getlist metodunu kullanıyoruz ve gelen değeri component çağrılan yere gönderiyoruz)
        }


    }
}
