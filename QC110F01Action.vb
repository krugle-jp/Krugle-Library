Imports Jp.Co.OtsukaShokai.MJPC.Client.Base.Util
Imports Jp.Co.OtsukaShokai.MJPC.Common.Base.Dto
Imports Jp.Co.OtsukaShokai.MJPC.Dto
Imports Jp.Co.OtsukaShokai.MJPC.Client.BusinessCommon.BaseCommon.Util

Namespace ClientTest.Actions

    Public Class QC110F01Action
        Inherits Jp.Co.OtsukaShokai.MJPC.Client.Base.Actions.BaseAction

        ''' <summary>
        ''' 確認内容検索
        ''' </summary>
        ''' <param name="req"></param>
        ''' <returns></returns>
        Public Function Getkakuninnaiyou(req As ParameterRequestDto) As ParameterResponseDto
			Dim res As New ParameterResponseDto
            Try
                '確認要
                Dim formId = MyBase.FormId
                Dim buttonId = MyBase.ButtonId
                Dim requestId = MyBase.RequestId
                res.KakuninNaiyou_Response = ""

                '部品呼び出し
                Dim settingutil As New SettingUtil(formId, buttonId, requestId)
                Dim SettingDataList As New List(Of SettingDto)

                '#7778(ST1_#2588) start
                SettingDataList = settingutil.GetDefaultSettingDataForSystem()

                For Each settingDto In SettingDataList
                    If "取込確認内容".Equals(settingDto.Section) Then
                        res.KakuninNaiyou_Response = settingDto.Value
                        Exit For
                    End If
                Next
                '#7778(ST1_#2588) end
                Return res
            Catch ex As Exception
                Dim exceptionUtil As New ClientExceptionLogOutputUtils()
                If (exceptionUtil.HandleException(ex)) Then
                    Throw
                End If
                Return res
            End Try
        End Function

    End Class

End Namespace