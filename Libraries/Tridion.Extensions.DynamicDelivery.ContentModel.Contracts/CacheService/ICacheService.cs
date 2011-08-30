using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tridion.Extensions.DynamicDelivery.ContentModel.Caching
{
	public interface ICacheService 
	{
		void AddItem(string Key, object Value);
		void AddItem(string Key, object Value, object CacheDependency, DateTime AbsoluteExpiration, TimeSpan SlidingExpiration);
		object GetItem(string Key);
		bool ContainsKey(string Key);
		bool ContainsLastPublishDate(string key);
		void SetLastPublishDate(string key, DateTime value);
		DateTime GetLastPublishDate(string key);
	}
}
