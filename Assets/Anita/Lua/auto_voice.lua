--- length of the voice filename after padding zeros to the left
local pad_len = 2

function auto_voice_on(name, index)
    __Anita.autoVoice:SetEnabled(name, true)
    __Anita.autoVoice:SetIndex(name, index)
end

function auto_voice_off(name)
    __Anita.autoVoice:SetEnabled(name, false)
end

local auto_voice_delay = 0

function set_auto_voice_delay(value)
    auto_voice_delay = value
end

local auto_voice_overridden = false

function auto_voice_skip()
    auto_voice_overridden = true
end

add_action_after_lazy_block(function(name)
    if auto_voice_overridden then
        auto_voice_overridden = false
        return
    end
    if name == nil or name == '' then
        return
    end
    if not __Anita.autoVoice:GetEnabled(name) then
        return
    end
    local chara = __Anita.autoVoice:GetCharacterController(name)
    local audio_name = __Anita.autoVoice:GetAudioName(name)
    say(chara, audio_name, auto_voice_delay, false)
    __Anita.autoVoice:IncrementIndex(name)
    auto_voice_delay = 0
end)
