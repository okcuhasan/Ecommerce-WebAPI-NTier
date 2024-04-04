using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Project.WebAPI.ExtensionClasses
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session,string key,object value) // key -> saklanacak nesneyi belirlemek için kullanılan anahtar - value -> saklanacak nesne
        {
            string objectString = JsonConvert.SerializeObject(value); // verdiğim value yu JSON formata çeviriyorum
            session.SetString(key, objectString); // session da saklıyorum - key değeri anahtarı - object string değişkeni saklanacak nesne
        }

        public static T GetObject<T>(this ISession session,string key) where T : class
        {
            string objectString = session.GetString(key); // belirtilen anahtardan oturumda saklanan nesneyi alıyorum
            if(string.IsNullOrEmpty(objectString))
            {
                return null;
            }
            T deserializedObject = JsonConvert.DeserializeObject<T>(objectString); // aldığım nesneyi JSON formattan normal veri formatına çeviriyorum ve dönüyorum
            return deserializedObject;
        }
    }
}
