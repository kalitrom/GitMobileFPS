using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LibraryEyeMonster : Character
{
    [SerializeField] private int damageToPlayer;

    [Header("Monster parts")]

    [SerializeField] private GameObject EyeMonsterFinger;
    [SerializeField] private GameObject EyeMonsterTrail;

    [Header("Monster parts position")]

    [SerializeField] Transform EyeMonsterFingerPosition;
    [SerializeField] Transform EyeMonsterTrailPosition01;
    [SerializeField] Transform EyeMonsterTrailPosition02;
    [SerializeField] Transform EyeMonsterTrailPosition03;
    [SerializeField] Transform EyeMonsterTrailPosition04;

    [Header("Monster audio")]

    [SerializeField] private AudioSource eyeMonsterTrailAudio_01;
    [SerializeField] private AudioSource eyeMonsterTrailAudio_02;
    [SerializeField] private AudioSource eyeMonsterTrailAudio_03;
    [SerializeField] private AudioSource eyeMonsterTrailAudio_04;

    private LibraryEyeMonsterTrail libraryEyeMonsterTrail;
    Character playerEnemy;
    private bool stopMonster;
    private int monsterTime;

    private void Start()
    {
        EyeMonsterFinger.transform.position = EyeMonsterFingerPosition.position;
        EyeMonsterTrail.transform.position = EyeMonsterTrailPosition01.position;
        libraryEyeMonsterTrail = FindObjectOfType<LibraryEyeMonsterTrail>();
        if (libraryEyeMonsterTrail == null)
        {
            Debug.Log("Can't find libraryEyeMonsterTrail");
        }
        StartCoroutine(EyeMonsterTrailAttack());
        playerEnemy = FindObjectOfType<Player>();
        if (playerEnemy == null)
        {
            Debug.Log("Can't find playerEnemy");
        }
    }

    private void PositionRotateAttack(Transform point, AudioSource audio)
    {
        RandomizeMonsterAttackTime();
        EyeMonsterTrail.transform.position = point.position;
        EyeMonsterTrail.transform.rotation = point.rotation;
        libraryEyeMonsterTrail.AttackAndReturn();
        audio.Play();
    }

    private void RandomizeMonsterAttackTime()
    {
        monsterTime = Random.Range(5, 8);
    }

    IEnumerator EyeMonsterTrailAttack()
    {
        while (stopMonster == false)
        {
            PositionRotateAttack(EyeMonsterTrailPosition01, eyeMonsterTrailAudio_01);
            yield return new WaitForSeconds(monsterTime);
            PositionRotateAttack(EyeMonsterTrailPosition02, eyeMonsterTrailAudio_02);
            yield return new WaitForSeconds(monsterTime);
            PositionRotateAttack(EyeMonsterTrailPosition03, eyeMonsterTrailAudio_03);
            yield return new WaitForSeconds(monsterTime);
            PositionRotateAttack(EyeMonsterTrailPosition04, eyeMonsterTrailAudio_04);
            yield return new WaitForSeconds(monsterTime);
        }
    }

    public void PlayerDamage()
    {
        playerEnemy.TakeDamage(damageToPlayer);
    }
}

