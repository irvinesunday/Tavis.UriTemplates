﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tavis.UriTemplates
{
    public class UriTemplateTable
    {
        private Dictionary<string,UriTemplate> _Templates =  new Dictionary<string,UriTemplate>();
        
        public void Add(string key, UriTemplate template)
        {
            _Templates.Add(key,template);
        }

        public TemplateMatch Match(Uri url)
        {
            foreach (var template in _Templates )
            {
                var parameters = template.Value.GetParameters(url);
                if (parameters != null)
                {
                    return new TemplateMatch() { Key = template.Key, Parameters = parameters, Template = template.Value };
                }
            }
            return null;
        }


    }

    public class TemplateMatch
    {
        public string Key { get; set; }
        public UriTemplate Template {get;set;}
        public IDictionary<string,object> Parameters {get;set;}
    }
}