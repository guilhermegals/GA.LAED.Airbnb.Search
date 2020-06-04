using System.Collections.Generic;

namespace GA.LAED.Airbnb.Search
{
    /// <summary>
    /// Estrutura de dados da Tabela Hash para o Airbnb
    /// </summary>
    public class AirbnbHashTable
    {
        #region [ Properties ]

        /// <summary>
        /// Chave de busca
        /// </summary>
        private readonly int _key;

        /// <summary>
        /// Tamanho da tabela
        /// </summary>
        private readonly int _size;

        /// <summary>
        /// Tabela Hash com Listas Encadeadas
        /// </summary>
        private readonly List<Airbnb>[] _table;

        #endregion

        #region [ Constructor ]

        /// <summary>
        /// Construtor
        /// </summary>
        public AirbnbHashTable(int key, int size)
        {
            this._key = key;
            this._size = size;
            this._table = new List<Airbnb>[this._size];
        }

        #endregion

        // TODO: Criar a tabela hash
    }
}