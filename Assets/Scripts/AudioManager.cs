using System.Xml.Schema;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private MenuAudio menuAudio;
    private BookAudio bookAudio;
    private ChecklistAudio checklistAudio;
    private ObjAudio objAudio;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checklistAudio = GetComponent<ChecklistAudio>();
        menuAudio = GetComponent<MenuAudio>();
        bookAudio = GetComponent<BookAudio>();
        objAudio = GetComponent<ObjAudio>();
    }

    public void MenuSFX() //open/close menu sfx
    {
        menuAudio.PlayMenuSFX();
    }

    public void SniffSFX()
    {
        menuAudio.PlaySniffSFX();
    }

    public void TasteSFX() 
    {
        menuAudio.PlayTasteSFX();
    }

    public void CheckSFX() //audio for clicking checkboxes on checklist
    {
        checklistAudio.PlayToggleSFX();
    }

    public void PaperSFX() //audio for open/close checklist
    {
        checklistAudio.PlayPaperSlideSFX();
    }

    public void WriteSFX() //sfx for checklist dropdowns
    {
        checklistAudio.PlayWritingSFX();
    }

    public void PageTurnSFX() //sfx when turning pages in guidebook
    {
        bookAudio.PlayPageTurnSFX();
    }

    public void OpenBookSFX() //sfx when opening guidebook
    {
        bookAudio.PlayOpenBookSFX();
    }

    public void CloseBookSFX() //sfx for closing guidebook
    {
        bookAudio.PlayCloseBookSFX();
    }

    public void DropBellSFX() //sfx when bell falls onto desk
    {
        objAudio.PlayBellDropSFX();
    }

    public void RingBell() //plays when bell clicked
    {
        objAudio.PlayBellRingSFX();
    }

    public void PotionClink()
    {
        objAudio.PlayPotionClink();
    }

    public void PickupTool() //sound when tool grabbed
    {
        objAudio.PlayToolPickupSFX();
    }

    public void GetDroplet() //sfx for dropper getting droplet
    {
        objAudio.PlayDropperSound();
    }

    public void StampSFX() //sfx for stamping stamp
    {
        objAudio.PlayStampSound();
    }

    public void CandleSFX() //sound of candle burning
    {
        objAudio.PlayCandleSound();
    }
}
