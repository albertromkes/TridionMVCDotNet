using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Web;
using System.Web.Caching;
using Tridion.Extensions.DynamicDelivery.ContentModel.Caching;

namespace Tridion.Extensions.DynamicDelivery.CachService {

	[Export(typeof(ICacheService))]
	public class CacheService : ICacheService
	{
		private static Cache cache = HttpContext.Current.Cache;
		
		#region ICacheService Members
		
		public void AddItem(string key, object value) {			
			cache.Insert(key, value);
		}

		public void AddItem(string Key, object Value, object CacheDependency, DateTime AbsoluteExpiration, TimeSpan SlidingExpiration) {
			cache.Insert(Key, Value, CacheDependency as CacheDependency, AbsoluteExpiration, SlidingExpiration); //TODO should this be configurable?
		}

		public object GetItem(string key) {
			return cache[key];
		}

		public bool ContainsKey(string key) 
		{
			return (cache.Get(key) != null);
		}


		private static IDictionary<string, DateTime> lastPublishedDates = new Dictionary<string, DateTime>();

		public bool ContainsLastPublishDate(string key)
		{
			return lastPublishedDates.ContainsKey(key);
		}

		public void SetLastPublishDate(string key, DateTime value) 
		{
			lastPublishedDates[key] = value;
		}

		public DateTime GetLastPublishDate(string key) {
			return lastPublishedDates[key];
		}
	
		#endregion


		
	}
}
