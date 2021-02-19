using System;
using System.Collections.Generic;

namespace Models
{
    public class ReleasesDTO
    {
        public ReleaseNotesDTO CurrentRelease;
        public List<ReleaseNotesDTO> ReleaseNotes;
        public ReleasesDTO(ReleaseNotesDTO currentRelease, List<ReleaseNotesDTO> releaseNotes) {
            CurrentRelease = currentRelease;
            ReleaseNotes = releaseNotes;
        }
    }

    public class ReleaseNotesDTO
    {
        public string Version;
        public DateTime ReleaseDate;
        public string Notes;
        public ReleaseNotesDTO(string version, DateTime releaseDate, string notes) {
            Version = version;
            ReleaseDate = releaseDate;
            Notes = notes;
        }
    }

    public class MarketingMaterialDTO
    {
        public string Title;
        public string Description;
        public string MediaUrl;
        public string ThumbnailUrl;
        public MarketingMaterialDTO(string title, string description, string mediaUrl, string thumbnailUrl) {
            Title = title;
            Description = description;
            MediaUrl = mediaUrl;
            ThumbnailUrl = thumbnailUrl;
        }
    }

}