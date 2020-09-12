function produce {
    begin { "begin "}
    process { "process" }
    end { "end" }
}

function consume {
    param(
        [Parameter(ValueFromPipeline)]
        $Item
    )
    begin {
        $items = @()
    }
    process {
        $items += $Item
    }
    end {
        "end:"
        $items|Write-Host
    }
}

produce|consume