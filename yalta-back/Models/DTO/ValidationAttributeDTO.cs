using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Yalta.Models.DTO
{
  public class ProfilValidationPreferredPeriodMinOneMaxThree : ValidationAttribute
  {
    protected override ValidationResult IsValid(object value, System.ComponentModel.DataAnnotations.ValidationContext validationContext)
    {
      var profil = (ProfilUpdateDTO)validationContext.ObjectInstance;
      if(profil.PreferredPeriods == null)
      {
        return new ValidationResult(ErrorMessage);
      }

      var preferredPeriodsCount = profil.PreferredPeriods.Count;
      if(preferredPeriodsCount < 1 || preferredPeriodsCount > 3)
      {
        return new ValidationResult(ErrorMessage);
      }

      return ValidationResult.Success;
    }
  }
}
