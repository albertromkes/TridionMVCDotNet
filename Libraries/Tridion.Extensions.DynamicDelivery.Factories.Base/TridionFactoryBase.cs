using Tridion.Extensions.DynamicDelivery.Utilities;
using Tridion.Extensions.DynamicDelivery.ContentModel.Caching;
using System.Text;
using System;
using System.Security.Cryptography;


namespace Tridion.Extensions.DynamicDelivery.Factories
{
    /// <summary>
    /// Base class for all TridionFactorys
    /// </summary>
    public abstract class TridionFactoryBase 
    {

		public TridionFactoryBase() 
		{
			CacheService = ServiceLocator.GetInstance<ICacheService>();
		}

		protected ICacheService CacheService { get; private set; }

		/// <summary>
        /// Returns the current publicationId
        /// </summary>  
        protected virtual int PublicationId 
        {
            get
            {
                return TridionHelper.PublicationId;
            }
        }

		///<summary>
		/// Returns a Cache Key based on a url and the publicationId
		/// </summary>
		protected virtual string GetCacheKey(string prefix, string key) 
		{
			StringBuilder sb = new StringBuilder(key);
			sb.Append(PublicationId); //Url should be unique in a publication
			sb.Append(prefix);       
			byte[] input = Encoding.UTF8.GetBytes(sb.ToString());
			byte[] output = MD5.Create().ComputeHash(input);
			return Convert.ToBase64String(output);
		}


    }
}
