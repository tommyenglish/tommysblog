using System.Collections.Generic;
using tommysblog._Data.Models;

namespace tommysblog.Data
{
    public partial class Dataservice
    {
        Quote[] quotes = new Quote[] 
        { 
            new Quote { Source="Mere Christianity", Content="Do not waste time bothering whether you 'love' your neighbor; act as if you do, and you will presently come to love him." }, 
            new Quote { Source="The Problem of Pain", Content="God allows us to experience the low points of life in order to teach us lessons that we could learn in no other way." }, 
            new Quote { Source="God In The Dock", Content="Christianity, if false, is of no importance and, if true, is of infinite importance. The one thing it cannot be is moderately important." }, 
            new Quote { Source="Mere Christianity", Content="Pride gets no pleasure out of having something, only out of having more of it than the next man." }, 
            new Quote { Source="God In The Dock", Content="If you want a religion to make you feel really comfortable, I certainly don’t recommend Christianity." }, 
            new Quote { Source="Mere Christianity", Content="Humility is not thinking less of yourself, but thinking of yourself less." }, 
            new Quote { Source="Essays on Forgiveness", Content="To be a Christian means to forgive the inexcusable, because God has forgiven the inexcusable in you." }, 
            new Quote { Source="Mere Christianity", Content="The Son of God became a man to enable men to become sons of God." }, 
            new Quote { Source="The Four Loves", Content="Don't let your happiness depend on something you may lose." }, 
            new Quote { Source="Is Theology Poetry", Content="I believe in Christianity as I believe that the sun has risen — not only because I see it, but because by it I see everything else." }
        };

        public IEnumerable<Quote> GetLewisQuotes()
        {
            return quotes;
        }
    }
}