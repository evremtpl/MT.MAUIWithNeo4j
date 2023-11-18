﻿using PropertyChanged;


namespace MT.MAUIWithNeo4j.Core
{
    
        [AddINotifyPropertyChangedInterface]
        public class MyTask
        {
            public string TaskName { get; set; }
            public bool Completed { get; set; }
            public int CategoryId { get; set; }
            public string TaskColor { get; set; }

        }
    
}
