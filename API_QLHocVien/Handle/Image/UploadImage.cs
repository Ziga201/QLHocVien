﻿using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace API_QLHocVien.Handle.Image
{
    public class UploadImage
    {
        //Account account = new Account("dnfnp1vdp","651395863673797","1f9u7M6yUZUemqVvLqT0sM6bvP4");
        //Cloudinary cloudinary = new Cloudinary(account);

        static string cloudName = "dnfnp1vdp";
        static string apiKey = "651395863673797";
        static string apiSecret = "1f9u7M6yUZUemqVvLqT0sM6bvP4";
        static public Account account = new Account(cloudName, apiKey, apiSecret);
        static public Cloudinary _cloudinary = new Cloudinary(account);
        public static async Task<string> Upfile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("Không có tập tin được chọn.");
            }
            using (var stream = file.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, stream),
                    PublicId = "xyz-abc" + "_" + DateTime.Now.Ticks + "image",
                    Transformation = new Transformation().Width(300).Height(400).Crop("fill")
                };
                var uploadResult = await UploadImage._cloudinary.UploadAsync(uploadParams);
                if (uploadResult.Error != null)
                {
                    throw new Exception(uploadResult.Error.Message);
                }
                string imageUrl = uploadResult.SecureUrl.ToString();
                return imageUrl;
            }
        }
    }
}
