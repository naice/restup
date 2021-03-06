﻿using Devkoes.Restup.WebServer.Attributes;
using Devkoes.Restup.WebServer.Models.Schemas;
using System;
using System.Globalization;

namespace Devkoes.Restup.DemoControllers
{
    [RestController(InstanceCreationType.Singleton)]
    public class SingletonControllerSample
    {
        private long _totalNrOfCallsHandled;

        public class WebserverInfo
        {
            public long TotalCallsHandled { get; set; }
        }

        [UriFormat("/singleton")]
        public GetResponse GetSingletonSampleValue()
        {
            return new GetResponse(
                GetResponse.ResponseStatus.OK,
                new WebserverInfo() { TotalCallsHandled = _totalNrOfCallsHandled++ });
        }

    [UriFormat("/singletonwithparameter?p={v}")]
    public GetResponse GetSingletonSampleValueWithParameter(string v) {
      long.TryParse(v, out _totalNrOfCallsHandled);
      return new GetResponse(
          GetResponse.ResponseStatus.OK,
          new WebserverInfo() { TotalCallsHandled = _totalNrOfCallsHandled++ });
    }
  }
}
