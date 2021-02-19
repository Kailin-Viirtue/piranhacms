using System;
using System.Collections.Generic;

namespace Models
{
    public class Releases
    {
        public ReleaseNotes CurrentRelease;
        public List<ReleaseNotes> ReleaseNotes;
        public Releases(ReleaseNotes currentRelease, List<ReleaseNotes> releaseNotes) {
            CurrentRelease = currentRelease;
            ReleaseNotes = releaseNotes;
        }
    }

    public class ReleaseNotes
    {
        public string Version;
        public DateTime ReleaseDate;
        public string Notes;
        public ReleaseNotes(string version, DateTime releaseDate, string notes) {
            Version = version;
            ReleaseDate = releaseDate;
            Notes = notes;
        }
    }

    public class MarketingMaterial
    {
        public string Title;
        public string Description;
        public string DownloadLink;
        public string ThumbnailLink;
        public MarketingMaterial(string title, string description, string downloadLink, string thumbnailLink) {
            Title = title;
            Description = description;
            DownloadLink = downloadLink;
            ThumbnailLink = thumbnailLink;
        }
    }

}