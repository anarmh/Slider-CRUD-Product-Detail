using FiorelloFront.Models;
using System.Collections;

namespace FiorelloFront.ViewModels
{
    public class HomeVM
    {
        public int Id { get; set; }
        public IEnumerable<Slider> Sliders { get; set; }
        public SliderInfo SliderInfo { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public About About { get; set; }
        public IEnumerable<FlowersExpert> FlowersExperts { get; set; }
        public IEnumerable<Say> Says { get; set; }
        public IEnumerable<Instagram> Instagrams { get; set; }
    }
}
