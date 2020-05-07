using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using Iuliia.Utils;

namespace Iuliia.Dto
{
    internal static class SchemeReader
    {
        public static Scheme Read(byte[] file)
        {
            var dto = JsonSerializer.Deserialize<SchemeDto>(file);


            return new Scheme(
                dto.Name,
                GetMapping(dto.Mapping.ToDictionary(k => k.Key[0], v => v.Value)),
                GetPreviousMapping(dto.PreviousMapping),
                GetNextMapping(dto.NextMapping),
                GetEndingMapping(dto.EndingMapping),
                dto.Samples.Select(s => new Sample(s[0], s[1])).ToArray());
        }
        
        private static Dictionary<char, string> GetMapping(IDictionary<char, string> mapping)
        {
            if (mapping == null)
                return new Dictionary<char, string>();
            
            var result = new Dictionary<char, string>(mapping);
            
            // do not use deconstruct (key, value) syntax for compatibility with netstandard2.0
            foreach (var pair in mapping) 
                result[char.ToUpper(pair.Key)] = pair.Value.Capitalize();

            return result;
        } 
        
        private static Dictionary<string, string> GetPreviousMapping(IDictionary<string, string> mapping)
        {
            if (mapping == null)
                return new Dictionary<string, string>();
            
            var result = new Dictionary<string, string>(mapping);
            
            foreach (var pair in mapping)
            {
                result[pair.Key.Capitalize()] = pair.Value;
                result[pair.Key.ToUpper()] = pair.Value.Capitalize();
            }

            return result;
        }

        private static Dictionary<string, string> GetNextMapping(IDictionary<string, string> mapping)
        {
            if (mapping == null)
                return new Dictionary<string, string>();
            
            var result = new Dictionary<string, string>(mapping);
            
            foreach (var pair in mapping)
            {
                result[pair.Key.Capitalize()] = pair.Value.Capitalize();
                result[pair.Key.ToUpper()] = pair.Value.Capitalize();
            }

            return result;
        }
        
        private static Dictionary<string, string> GetEndingMapping(IDictionary<string, string> mapping)
        {
            if (mapping == null)
                return new Dictionary<string, string>();
            
            var result = new Dictionary<string, string>(mapping);
            
            foreach (var pair in mapping) 
                result[pair.Key.ToUpper()] = pair.Value.ToUpper();

            return result;
        }
    }
}