using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormManagement.Models
{
    public class FormMetaData
    {
        [Required(ErrorMessage = "Form adı boş girilemez")]
        [Display(Name = "Form Adı")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string formName { get; set; }

        [Display(Name = "Açıklama")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string description { get; set; }

        [Required(ErrorMessage = "Ad alanı gereklidir.")]
        [Display(Name = "Adı")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Soyad alanı gereklidir.")]
        [Display(Name = "Soyadı")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string surname { get; set; }

        [Display(Name ="Yaş")]
        public string age { get; set; }
    }
    public class UserMetaData
    {
        [Required(ErrorMessage = "Kullanıcı adı gereklidir")]
        [Display(Name = "Kullanıcı Adı")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Kullanıcı adı en çok 50 karakter içerebilir")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9]{3,49}$", ErrorMessage = "En az 3 en çok 50 karakter ve (yalnızca harf ve sayı) içerebilir.")]
        public string username { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Parola en çok 50 karakter içerebilir.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Parola  en az 8 karakter,1 büyük harf, 1 küçük harf ve 1 sayı içermelidir. Özel karakter girmeyiniz.")]
        public string password { get; set; }
    }


    [MetadataType(typeof(FormMetaData))]
    public partial class Form
    {

    }

    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {

    }
}