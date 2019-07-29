using System.Collections.Generic;

namespace mssmscm {
    public class ConnectionNode {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Hostname { get; set; }

        public string Database { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public List<ConnectionNode> Children { get; set; }
    }
}