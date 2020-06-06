namespace GA.LAED.Airbnb.Search
{
    /// <summary>
    /// Nó Airbnb
    /// </summary>
    public class AirbnbNode
    {
        #region [ Properties ]

        /// <summary>
        /// Valor do Nó
        /// </summary>
        /// <value>Objeto Airbnb</value>
        public Airbnb Value { get; private set; }

        /// <summary>
        /// Nó da Esquerda
        /// </summary>
        /// <value>Objeto AirbnbNode</value>
        public AirbnbNode Left { get; set; }

        /// <summary>
        /// Nó da Direita
        /// </summary>
        /// <value>Objeto AirbnbNode</value>
        public AirbnbNode Right { get; set; }

        #endregion

        #region [ Constructor ]

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="value">Valor do Nó</param>
        public AirbnbNode(Airbnb value)
        {
            this.Value = value;
            this.Left = this.Right = null;
        }

        #endregion
    }

    /// <summary>
    /// Estrutura de dados da Árvore Binária para Airbnb
    /// </summary>
    public class AirbnbBinaryTree
    {
        #region [ Properties ]

        /// <summary>
        /// Raiz da árvore
        /// </summary>
        /// <value>Objeto AirbnbNode</value>
        private AirbnbNode Root { get; set; }

        #endregion

        #region [ Constructor ]

        /// <summary>
        /// Construtor
        /// </summary>
        public AirbnbBinaryTree(Airbnb[] array)
        {
            // Inicializa a raíz da árvore
            this.Root = null;

            for (int i = 0; i < array.Length; i++)
            {
                // Insere os objetos na árvore
                this.Insert(array[i].GetCopy());
            }
        }

        #endregion

        #region [ Insert ]

        /// <summary>
        /// Insere um novo Airbnb na árvore
        /// </summary>
        /// <param name="airbnb">Objeto Airbnb</param>
        public void Insert(Airbnb airbnb)
        {
            this.Root = Insert(this.Root, airbnb);
        }

        /// <summary>
        /// Insere um objeto Airbnb no nó da árvore
        /// </summary>
        /// <param name="node">Nó</param>
        /// <param name="airbnb">Objeto Airbnb</param>
        /// <returns>Nó</returns>
        private AirbnbNode Insert(AirbnbNode node, Airbnb airbnb)
        {
            if (node == null)
                node = new AirbnbNode(airbnb);
            else
            {
                if (node.Value.RoomId > airbnb.RoomId)
                    node.Left = this.Insert(node.Left, airbnb);
                else if (node.Value.RoomId < airbnb.RoomId)
                    node.Right = this.Insert(node.Right, airbnb);
            }

            return node;
        }

        #endregion

        #region [ Search ]

        /// <summary>
        /// Realiza a busca pela árvore binária
        /// </summary>
        /// <param name="idRoom">Id Room</param>
        /// <param name="comparisons">Total de comparações</param>
        /// <returns>Objeto Airbnb</returns>
        public Airbnb Search(int idRoom, out int comparisons)
        {
            comparisons = 0;

            if (this.IsEmpity())
                return null;

            AirbnbNode node = Search(this.Root, idRoom, ref comparisons);

            if (node != null)
                return node.Value;

            return null;
        }

        private AirbnbNode Search(AirbnbNode node, int idRoom, ref int comparisons)
        {
            comparisons++;
            if (node != null)
            {
                if (node.Value.RoomId == idRoom)
                    return node;

                if (idRoom < node.Value.RoomId)
                    return Search(node.Left, idRoom, ref comparisons);
                else
                    return Search(node.Right, idRoom, ref comparisons);

            }

            return null;
        }

        #endregion

        public bool IsEmpity()
        {
            return this.Root == null;
        }
    }
}