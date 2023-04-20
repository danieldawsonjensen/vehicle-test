using System;
using Model;

namespace Model;

public class Image
{
    public Vehicle Vehicle { get; set; }
    public Uri VehicleImage { get; set; }

    public string ImageURI { get; set; } // placering af image

    public DateTime ImageDate { get; set; }
    public string ImageDescription { get; set; }
    public string ImageUploaderName { get; set; }

    public Image()
    {

    }
}
