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
        public string PageLength;
        public string Format;
        public string DownloadLink;
        public string ThumbnailLink;
        public MarketingMaterial(string title, string pageLength, string format, string downloadLink, string thumbnailLink) {
            Title = title;
            PageLength = pageLength;
            Format = format;
            DownloadLink = downloadLink;
            ThumbnailLink = thumbnailLink;
        }
    }

}