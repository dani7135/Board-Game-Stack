namespace Board_Game_Stack.Server.Models
{
    public class Game
    {
        public int Id { get; set; }
        public bool Played { get; set; }
        public  string Image { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string People { get; set; }
        public Timer Timer { get; set; }
        public TagsAttribute Tags { get; set; }
        public Type Type { get; set; }

        public string Publisher { get; set; }
         public string Ratings { get; set; }
        
    }
}
