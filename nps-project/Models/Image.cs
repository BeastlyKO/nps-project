#pragma warning disable
namespace nps_project.Models
{
    public class Image
    {
        //creditability to the author of the image
        public string credit { get; set; }

        //the title of the image
        public string title { get; set; }

        //alternative title to image
        public string altText { get; set; }
 
        // a caption for the image
        public string caption { get; set; }
 
        // the image url
        public string url { get; set; }

    }
}
