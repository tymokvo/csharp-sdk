using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PollinationSDK
{

    public static class JsonSetting
    {
		private static JsonSerializerSettings _setting;
		public static JsonSerializerSettings ConvertSetting
		{
			get {

				if (_setting == null)
				{
					_setting = new JsonSerializerSettings
					{
						NullValueHandling = NullValueHandling.Ignore,
						MissingMemberHandling = MissingMemberHandling.Ignore,
						Converters = new List<JsonConverter>() { new AnyOfJsonConverter() }
					};
				}
				return _setting; 
			}
		}

	}
}