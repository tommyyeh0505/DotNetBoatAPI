using System;
using System.ComponentModel.DataAnnotations;

namespace A1backend.ViewFolders
{
    public class Boat
    {
        [Required]
        public string BoatId { get; set; }

        [Required]
        public string BoatName { get; set; }

        [Required]
        public string Picture { get; set; }

        [Required]
        public string LengthFeet { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Description { get; set; }

    }
}
