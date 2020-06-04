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
        public AirbnbBinaryTree()
        {
            // Inicializa a raíz da árvore
            this.Root = null;
        }

        #endregion

        // TODO: Criar árvore binária

    }
}