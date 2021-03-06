﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    //Cross Cutting Concerns : Log, Cache, Transaction, Authorization,...
    public static class ValidationTool
    {
        public static void Validate(IValidator validator,object entity) //Burdan ProductValidator ulaşıyoruz
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid) //sonuç geçerli değilse hata fırlat
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
