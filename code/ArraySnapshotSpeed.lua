
--[[----------------------------------------------------------
created:    2018-01-02
author:     lixianmin

Copyright (C) - All Rights Reserved
------------------------------------------------------------]]

local require, print = require, print
local Time = UnityEngine.Time

function _RunByWatch (repeatCount, method, ...)
    local startTime = Time.realtimeSinceStartup
    for i=1, repeatCount do
        method(...)
    end
    local endTime = Time.realtimeSinceStartup
    local seconds = endTime - startTime
    return seconds
end

function table.clonei (src, dest)
    if not src then
        return
    end

    dest = dest or {}

    local count = #src
    for i = 1, count do
        dest[i] = src[i]
    end

    for i = count+1, #dest do
        dest[i] = nil
    end

    return dest
end

function _TestRawArray (rawArray)
    for i=1, #rawArray do
        local item = rawArray[i]
    end
end

function _TestCopyToSnapshot (rawArray, snapshotArray)
    table.clonei(rawArray, snapshotArray)

    for i=1, #snapshotArray do
        local item = snapshotArray[i]
    end
end

local rawArray = {}
local snapshotArray = {}
local size = 8192

for i= 1, size do
    table.insert(rawArray, i)
end

for i=1, 10 do
    local repeatCount = 50
    local rawArrayTime = _RunByWatch(repeatCount, _TestRawArray, rawArray)
    local copyToSnapshotTime = _RunByWatch(repeatCount, _TestCopyToSnapshot, rawArray, snapshotArray)
    print ('============> ratio='..tostring(copyToSnapshotTime/rawArrayTime))
end

