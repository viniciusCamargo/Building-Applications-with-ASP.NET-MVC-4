using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    //public class MaxWordsAttribute : ValidationAttribute
    //{
    //    /*
    //     * This specific custom validation will happens only on the server
    //     * side. But I could implement custom JS to plug to the client side
    //     * validation framework.
    //     *
    //     * The base will be used by the FormatErrorMessage method to set the
    //     * errorMessage, in this case {0} will be replaced by the DisplayName.
    //     */
    //    public MaxWordsAttribute(int maxWords) : base("{0} has too many words.")
    //    {
    //        _maxWords = maxWords;
    //    }

    //    /* The value here would be the property where this attribute was applied */
    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        if (value != null)
    //        {
    //            var valueAsString = value.ToString();
    //            if (valueAsString.Split(' ').Length > _maxWords)
    //            {
    //                var errorMessage = FormatErrorMessage(validationContext.DisplayName);
    //                return new ValidationResult(errorMessage);
    //            }
    //        }
    //        return ValidationResult.Success;
    //    }

    //    private readonly int _maxWords;
    //}

    //public class RestaurantReview : IValidatableObject
    public class RestaurantReview
    {
        public int Id { get; set; }

        // Custom error message
        //[Range(1,10, ErrorMessage = "string")]
        [Range(1,10)]
        [Required]
        /*
         * V A L I D A T I O N   A N N O T A T I O N S   OR
         * D A T A   A N N O T A T I O N   F O R   V A L I D A T I O N
         *
         * The Required attribute here would not be necessary since the
         * model binder requires integers by default. "Because integers
         * in C# are value types, that means it cannot be null". Other
         * required value types would be DateTime, long and decimal.
         */
        public int Rating { get; set; }

        /*
         * The validation of the EditorFor HTML helper will occur both on
         * client and server side. So it'll works even if the user has JS
         * disabled on the browser.
         */
        [Required]
        [StringLength(1024)]
        public string Body { get; set; }

        /* Change the content of the input's label */
        [Display(Name = "User Name")]
        /*
         * Set a display value for the input in case none is provided, the
         * actual value submitted to the DB will be NULL.
         */
        [DisplayFormat(NullDisplayText = "anonymous")]
        //[MaxWords(1)]
        public string ReviewerName { get; set; }
        public int RestaurantId { get; set; }
        /*
         * The Entity Framework always check the model that's been used and
         * the model used to create the database, so by changing our model
         * we'll also break our application, since adding data annotations
         * actually change our database schema too.
         * 
         * To fix this I should migrate my new model to the schema with:
         * "Update-Database -Verbose" at the package manager console.
         *
         * This first I run this command it fail because I'm changing a
         * column (Body) that used to be nvarchar max (up to 2GB of storage)
         * to 1024 characters, resulting in data loss. So I have to force the 
         * migration with the -Force flag: "Update-Database -Verbose -Force".
         */

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Rating < 2 && ReviewerName.ToLower().StartsWith("scott"))
        //    {
        //        yield return new ValidationResult("Sorry, Scott, you can't do this");
        //    }
        //}

    }
}