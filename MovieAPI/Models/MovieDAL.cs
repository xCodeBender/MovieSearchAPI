using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MovieAPI.Models
{
    public class MovieDAL
    {
    
        public string GetMovieTitleFromJson(string title)
        {
            //make request to api
            string key = "4a45a52c";
            string url = $"http://www.omdbapi.com/?apikey={key}&t={title}";
            HttpWebRequest request = WebRequest.CreateHttp(url);
            //get and store responds from api
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //convert the raw Json to string

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();
            return JSON;
        }



        //convertion - string to object
        public MovieModel ConvertJSONtoSingleTitleMovieModel(string Title)
        {
            string rawJSON = GetMovieTitleFromJson(Title);
            MovieModel movie = JsonConvert.DeserializeObject<MovieModel>(rawJSON);
            return movie;
        }

        
    }
}
