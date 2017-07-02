using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace MatchMaker.Infrastructure.Repository
{
    public class BlobServices
    {
        byte[] Photo;
        public string UploadPhoto(string pEncode64, string pFileName)
        {
            string photoUrl;

            Photo = Convert.FromBase64String(pEncode64);

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference("userprofiles");

            container.CreateIfNotExists();

            container.SetPermissions(
                new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(pFileName);

            try
            {
                using (MemoryStream stream = new MemoryStream(Photo))
                {
                    blockBlob.UploadFromStream(stream);
                }
            }
            catch(Exception ex)
            {

            }

            return blockBlob.Uri.AbsoluteUri.ToString();
        }
    }
}
