using Tweetinvi.Models.V2;

namespace BlazorExample.Shared.Comparers;

public class TweetComparer: IEqualityComparer<TweetV2> {  
    public bool Equals(TweetV2 tweet1, TweetV2 tweet2) {  
        if (tweet1.Id.Equals(tweet2.Id)) {  
            return true;  
        }  
        return false;  
    }

    public int GetHashCode(TweetV2 obj)
    {
        return obj.Id.GetHashCode();  
    }
}  