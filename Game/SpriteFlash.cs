using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlash : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private void Awake(){
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    public IEnumerator FlashCouroutine(float flashDuration , Color flashColor , int numberOfFlashes){
        Color startColor = _spriteRenderer.color;
        float elapsedFlashTime =0;
        float elapsedFlashPercentage =0;

        while (elapsedFlashTime<flashDuration)
        {
            elapsedFlashTime +=Time.deltaTime;
            elapsedFlashPercentage = elapsedFlashTime/flashDuration;
            if (elapsedFlashPercentage>1)
            {
                elapsedFlashPercentage =1;
            } 
            float pingPongPercentage = Mathf.PingPong(elapsedFlashPercentage*2*numberOfFlashes,1);
            _spriteRenderer.color= Color.Lerp(startColor,flashColor,pingPongPercentage);
            yield return  null;
        }
    }
}
