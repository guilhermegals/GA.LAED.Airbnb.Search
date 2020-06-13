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
        public AirbnbHashTable(int key, Airbnb[] array)
        {
            this._key = key;
            this._size = key;
            this._table = new List<Airbnb>[this._size];

            int length = array.Length;
            for (int i = 0; i < length; i++)
            {
                int div = array[i].RoomId % this._key;
                if (this._table[div] == null)
                    this._table[div] = new List<Airbnb>();
                this._table[div].Add(array[i]);
            }
        }

        #endregion

        #region [ Search ]

        /// <summary>
        /// Realiza a busca pela tabela Hash
        /// </summary>
        /// <param name="idRoom">Id Room</param>
        /// <param name="comparisons">Total de comparações</param>
        /// <returns>Objeto Airbnb</returns>
        public Airbnb Search(int idRoom, out int comparisons)
        {
            comparisons = 0;

            int index = idRoom % this._key;
            List<Airbnb> list = this._table[index];

            foreach (Airbnb airbnb in list)
            {
                comparisons++;
                if (airbnb.RoomId == idRoom)
                    return airbnb;
            }

            return null;
        }

        #endregion
    }
}