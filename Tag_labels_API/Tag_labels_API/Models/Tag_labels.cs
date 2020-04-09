using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tag_labels_API.Models
{
    public class Tag_labels
    {
        private string id_;
        private string name_EN;

        public string Id_ { get => id_; set => id_ = value; }
        public string Name_EN { get => name_EN; set => name_EN = value; }

        public Tag_labels() { }

        public Tag_labels(string id_, string name_EN)
        {
            Id_ = id_;
            Name_EN = name_EN;
        }
        public int insert(Tag_labels tag_Labels)
        {
            DBservices dbs = new DBservices();
            int num = dbs.insert(tag_Labels);
            return num;
        }
    }
}