using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Play.Review;

public class RManager : MonoBehaviour
{
    private ReviewManager _reviewManager;
    private PlayReviewInfo _playReviewInfo;
    int launchCount;

    // Start is called before the first frame update
    void Start()
    {
        launchCount = PlayerPrefs.GetInt("TimesLaunched", 0);
        launchCount++;
        PlayerPrefs.SetInt("TimesLaunched", launchCount);
        Debug.Log("the app has been launched " +launchCount+" times");

        if ( launchCount >= 3)
        {
            StartCoroutine(RequestReviews());
            Debug.Log("ReviewRequestSent");
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RequestReviews()
    {
        _reviewManager = new ReviewManager();

        // request a review info object

        var requestFlowOperation = _reviewManager.RequestReviewFlow();
        yield return requestFlowOperation;
        if (requestFlowOperation.Error != ReviewErrorCode.NoError)
        {
            // Log error. For example, using requestFlowOperation.Error.ToString().
            yield break;
        }
        _playReviewInfo = requestFlowOperation.GetResult();

        // launch the in-app review flow

        var launchFlowOperation = _reviewManager.LaunchReviewFlow(_playReviewInfo);
        yield return launchFlowOperation;
        _playReviewInfo = null; // Reset the object
        if (launchFlowOperation.Error != ReviewErrorCode.NoError)
        {
            // Log error. For example, using requestFlowOperation.Error.ToString().
            yield break;
        }
        // The flow has finished. The API does not indicate whether the user
        // reviewed or not, or even whether the review dialog was shown. Thus, no
        // matter the result, we continue our app flow.

    }

}
