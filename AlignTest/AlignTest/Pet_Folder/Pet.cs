using AlignTest.Pet_Folder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AlignTest
{
    class Pet
    {
        public int id;
        public Category cat;
        public string name;
        public List<string> photoUrls = new List<string>();
        public List<Tag> tags = new List<Tag>();
        public status stat;
        public Pet(int id, Category cat, string name, List<string> photoUrls, List<Tag> tags, status stat)
        {
            this.id = id;
            this.cat = cat;
            this.name = name;
            this.photoUrls = photoUrls;
            this.tags = tags;
            this.stat = stat;
        }

        public void Update(Category cat, string name, List<Tag> tags, status stat)
        {
            this.cat = cat;
            this.name = name;
            this.tags = tags;
            this.stat = stat;
        }

        public void Update(Pet p)
        {
            this.cat = p.cat;
            this.name = p.name;
            this.tags = p.tags;
            this.stat = p.stat;
        }

        public override string ToString()
        {
            return "id : " + this.id.ToString() + "\n" +
                   "categoty: " + this.cat.ToString() + "\n" +
                   "name: " + this.name.ToString() + "\n" +
                   "tags: " + this.tags.ToString() + "\n" +
                   "status: " + this.stat;
        }

        public void UploadImage(string url)
        {
            this.photoUrls.Add(url);
        }
    }
}
