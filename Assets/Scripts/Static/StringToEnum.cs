using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringToEnum
{
    //string을 enum으로 변환 함수
    public static T FormatStringToEnum<T>(this string value) where T : struct
    {
        if (Enum.TryParse<T>(value, true, out var enumValue))
        {
            return enumValue;
        }
        else
        {
            throw new ArgumentNullException(nameof(value));
        }
    }
}
