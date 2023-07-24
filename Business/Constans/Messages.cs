using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constans
{
    public static class Messages
    {
        public static string CarAdded = "Ürün eklendi";
        public static string CarNameInvalid = "Ürün ismi geçersiz";
       
        internal static string CarsListed="Ürünler listelendi";
        internal static string MaintenanceTime="Sistem bakımda";

        // ------------CAR MESSAGES ------------------
        public static string AddedCar = "Araba eklendi.";
        public static string UpdatedCar = "Araba güncellendi.";
        public static string DeletedCar = "Araba silindi.";
        public static string CarNameInValid = "Araba adı en az iki karakterden oluşmalı";
        public static string CarPriceIsNegative = "Araba günlük fiyatı 0'dan büyük olmalıdır";

        // ------------ BRAND MESSAGES --------------
        public static string AddedBrand = "Marka eklendi.";
        public static string UpdatedBrand = "Marka güncellendi.";
        public static string DeletedBrand = "Marka silindi.";
        public static string BrandNameInValid = "Marka adı en az iki karakterden oluşmalı";

        // ------------ COLOR MESSAGES ---------------
        public static string AddedColor = "Renk eklendi.";
        public static string UpdatedColor = "Renk güncellendi.";
        public static string DeletedColor = "Renk silindi.";
        public static string ColorNameInValid = "Renk adı en az iki karakterden oluşmalı";

        // -------------- RENTAL MESSAGES ---------------
        public static string CarNotReturn = "İstediğiniz araç henüz teslim edilmemiş";

        public static string ImageAdded = "Resim Eklendi.";

        public static string CarImageDeleted = "Resim Silindi.";

        public static string ImagesListedById = "Resimler id'ye göre listelendi.";

        public static string ImageUpdated = "resimler güncellendi.";

        public static string CarImageLimitReached = "bir araç için maksimum sayıda yükleme yaptınız.";

        public static string CarImageAlreadyHave = "Bu resim daha önce eklenmişti.";

        public static string UserRegistered = "kullanıcı kaydoldu";
        public static string UserNotFound = "kullanıcı bulunamadı";
        public static string PasswordError = "parola hatalı";
        public static string SuccessfulLogin = "doğru giris";
        public static string UserAlreadyExists = "kullanıcı zaten var";
        public static string AccessTokenCreated = "token olusturuldu.";
        public static string AuthorizationDenied = "Yetkiniz yok";
    }
}
