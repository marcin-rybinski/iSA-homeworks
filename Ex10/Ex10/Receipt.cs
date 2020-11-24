using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex10
{
    public class Receipt
    {
        private readonly List<ReceiptLine> _lines;

        public Receipt()
        {
            _lines = new List<ReceiptLine>();
        }

        public IEnumerable<ReceiptLine> Lines => _lines;

        public int GetTotalNumberOfLines()
        {
            return _lines.Count;
        }

        public void ReverseLastLine()
        {
            if (!_lines.Any())
            {
                throw new InvalidOperationException("There is no lines. Nothing to reverse");
            }
            
            var last = _lines.Last();

            if (last.Title.Contains("Reversing"))
            {
                throw new InvalidOperationException("You can only reverse line once per product.");
            }

            _lines.Add(new ReceiptLine
                {
                    Number = last.Number,
                    PriceInUsd = -1 * last.PriceInUsd,
                    Title = $"[Reversing] {last.Title}"
                });
            
        }

        public void RecordLine(string title, int numberOfItems, int priceInUsd)
        {
            if (numberOfItems <= 0)
            {
                throw new InvalidOperationException($"You can't add line with {numberOfItems} items.");
            }

            if (priceInUsd <= 0)
            {
                throw new InvalidOperationException($"You can't add line with {priceInUsd} price.");
            }

            _lines.Add(new ReceiptLine
            {
                PriceInUsd = priceInUsd,
                Title = title,
                Number = numberOfItems
            });
        }

        public int CalculateTotalCost()
        {
            var totalPrice = 0;

            foreach (var line in _lines)
            {
                totalPrice = totalPrice + line.Number * line.PriceInUsd;
            }

            return totalPrice;
        }
    }
}
