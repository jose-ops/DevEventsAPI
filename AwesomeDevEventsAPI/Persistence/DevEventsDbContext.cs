using AwesomeDevEventsAPI.Entities;

namespace AwesomeDevEventsAPI.Persistence
{
    public class DevEventsDbContext
    {
        public List<DevEvents> DevEvents { get; set; }

        public DevEventsDbContext()
        {
            DevEvents = new List<DevEvents>();
        }
    }
}
