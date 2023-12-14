using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DIALOUGE
{
    public class AutoReader : MonoBehaviour
    {
        private ConversationManager conversationManager;
        private TextArchitect architect;

        public bool skip { get; set; } = false;
        public float speed { get; set; } = 1f;
    }
}