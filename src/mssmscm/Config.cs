using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace mssmscm {
    public class Config {
        /// <summary>
        /// Local config file path.
        /// </summary>
        private static string ConfigFile {
            get {
                return Path.Combine(
                    Application.LocalUserAppDataPath,
                    "connections.json");
            }
        }

        /// <summary>
        /// Load config from local JSON.
        /// </summary>
        public static List<ConnectionNode> Load() {
            if (!File.Exists(ConfigFile)) {
                return new List<ConnectionNode>();
            }

            try {
                return JsonConvert.DeserializeObject<List<ConnectionNode>>(
                    File.ReadAllText(ConfigFile));
            }
            catch (Exception ex) {
                MessageBox.Show(
                    string.Format(
                        "Unable to load config. {0}",
                        ex.Message),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return new List<ConnectionNode>();
        }

        /// <summary>
        /// Save treeview to local JSON.
        /// </summary>
        public static void Save(TreeNodeCollection nodes) {
            var list = new List<ConnectionNode>();

            foreach (TreeNode node in nodes) {
                Save(list, node);
            }

            File.WriteAllText(
                ConfigFile,
                JsonConvert.SerializeObject(list));
        }

        /// <summary>
        /// Recurse through the list.
        /// </summary>
        private static void Save(List<ConnectionNode> list, TreeNode node) {
            var tag = node.Tag.ToString();
            var item = new ConnectionNode {
                Name = node.Text,
                Type = tag == "FOLDER"
                    ? "folder"
                    : "connection"
            };

            if (tag != "FOLDER") {
                var sections = tag.Split(';');

                if (sections.Length == 5 &&
                    sections[0] == "CNT") {

                    item.Hostname = sections[1].Substring(9);
                    item.Database = sections[2].Substring(9);
                    item.Username = sections[3].Substring(9);
                    item.Password = sections[4].Substring(9);
                }
            }

            // Add children.
            if (node.Nodes.Count > 0) {
                item.Children = new List<ConnectionNode>();

                foreach (TreeNode nd in node.Nodes) {
                    Save(item.Children, nd);
                }
            }

            // Add to list.
            list.Add(item);
        }
    }
}