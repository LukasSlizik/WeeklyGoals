import { Serializable } from "./Serializable";

export class SimpleModel implements Serializable<SimpleModel> {

    public age: number;
    public name: string;

    constructor() {
    }

    deserialize(input: any): SimpleModel {
        this.age = input.age;
        this.name = input.name;

        return this;
    }
}