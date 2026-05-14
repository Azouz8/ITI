class BasicVolumeImpl {
    increaseVolume(v) { return Math.min(100, v + 10); }
    decreaseVolume(v) { return Math.max(0, v - 10); }
}

class MutableVolumeImpl extends BasicVolumeImpl {
    mute() { return 0; }
}

class Device {
    constructor(name, impl) {
        this.name = name;
        this.impl = impl;
        this.volume = 50;
    }
    increase() {
        this.volume = this.impl.increaseVolume(this.volume);
        return `${this.name} volume → ${this.volume}`;
    }
    decrease() {
        this.volume = this.impl.decreaseVolume(this.volume);
        return `${this.name} volume → ${this.volume}`;
    }
    mute() {
        if (typeof this.impl.mute !== "function")
            return `${this.name} does not support mute`;
        this.volume = this.impl.mute();
        return `${this.name} muted → volume: ${this.volume}`;
    }
}

const tv = new Device("TV", new BasicVolumeImpl());
const speaker = new Device("Speaker", new MutableVolumeImpl());

console.log(tv.increase());
console.log(tv.decrease());
console.log(tv.mute());
console.log(speaker.increase());
console.log(speaker.mute()); 