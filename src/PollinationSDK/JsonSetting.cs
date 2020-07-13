using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PollinationSDK.Model
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
						MissingMemberHandling = MissingMemberHandling.Ignore
					};
				}
				return _setting; 
			}
		}

	}
}